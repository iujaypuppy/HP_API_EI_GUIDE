
package hp.st.ext.java;
import java.util.HashMap;

public abstract interface ServiceTestCall
{
  public abstract HashMap<String, Class<?>> getInputProperties();
  
  public abstract HashMap<String, Class<?>> getOutputProperties();
  
  public abstract HashMap<String, Object> execute(HashMap<String, Object> paramHashMap);
}