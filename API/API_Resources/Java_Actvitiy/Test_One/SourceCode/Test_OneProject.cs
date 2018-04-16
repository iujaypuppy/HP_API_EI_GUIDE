using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using HP.ST.Ext.JavaCallAdaptor;
using HP.ST.Fwk.JVMLoader;
using HP.ST.Fwk.RunTimeFWK;
using HP.ST.Fwk.RunTimeFWK.Utilities;
using log4net;
using System.Net;
using System.ServiceModel.Web;
using System.Runtime.ExceptionServices;

namespace Test_OneProject
{
    [Serializable]
     public partial class Test_One : STActivityBase
    {
        /// <summary>
        /// The log4net Log
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(Test_One));

        /// <summary>
        /// Initializes a new instance of the Activity class.
        /// </summary>
        /// <param name="ctx"> activitie's Context </param>
        /// <param name="name"> The activity name. </param>
        public Test_One(ISTRunTimeContext ctx, string name)
            : base(ctx, name)
        {
            
        }

        /// <summary>
        /// Execue and set results
        /// </summary>
        /// <returns></returns>
       [HandleProcessCorruptedStateExceptions]
       protected override STExecutionResult ExecuteStep()
       {
            WebServiceHost serviceHost = null;
            const string returnValueKey = "ExecutionResult_E5F7897B-20DF-4E6F-9AB8-00519844ABA9";
            try
            {   
                serviceHost = new WebServiceHost(this,new Uri("http://localhost:17266/LogReportService"));
                serviceHost.Open();
   
                var InputProperties = new Dictionary<string, KeyValuePair<Type, object>>();
                var OutputProperties = new Dictionary<string, Type>();
                
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                JVMLoader.LoadJVM(path, "");
                    
                OutputProperties.Add(returnValueKey, typeof(System.String));


                InputProperties.Add("value", new KeyValuePair<Type, object>(typeof(System.String), value));
                InputProperties.Add("Name", new KeyValuePair<Type, object>(typeof(System.String), Name));


                var Results = JavaCaller.Execute("hp/custom/java/activity/ServiceTestCallImpl", InputProperties, OutputProperties);



                if (Results.ContainsKey(returnValueKey) && ((System.String)Results[returnValueKey]).Equals("Success"))
                {
                    return new STExecutionResult(STExecutionStatus.Success);
                }
                return new STExecutionResult(STExecutionStatus.ActivityFailure);

            }
            catch (AccessViolationException e)
            {
                throw new Exception(string.Format("Running Java steps is not supported."));
            }
            catch (Exception e)
            {
                return new STExecutionResult(STExecutionStatus.ActivityFailure);
            }
            finally
            {
                if(serviceHost != null)
                    serviceHost.Close();
           }
        }
   }
}
