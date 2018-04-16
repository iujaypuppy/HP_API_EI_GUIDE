package hp.custom.java.activity;

public class MyLogic {
	
	public Properties Props = new Properties();

	public ExecutionResult ExecuteLogic()
	{
		try{

		    Logger.LogInfo("This is activity Test_One");
			
			return ExecutionResult.Success;

		}
		catch(Exception e)
		{

		  return ExecutionResult.Failure;

		}

		
		
		
	}


	
	public enum ExecutionResult {

		Success ,
		Failure ;
		
	}

}
