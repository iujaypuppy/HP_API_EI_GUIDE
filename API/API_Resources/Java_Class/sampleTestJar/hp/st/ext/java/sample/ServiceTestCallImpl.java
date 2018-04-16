package hp.st.ext.java.sample;
import java.util.HashMap;
import hp.st.ext.java.ServiceTestCall;

public class ServiceTestCallImpl implements ServiceTestCall {

	public HashMap<String, Object> execute(
			HashMap<String, Object> inputProperties) {
		
		HashMap<String, Object> outProps = new HashMap<String, Object>();
		String name = (String)inputProperties.get("name");
		Integer age = (Integer)inputProperties.get("age");
		
		// you can add your logical code here
		
		outProps.put("result", name);
		
		return outProps;
	}

	public HashMap<String, Class<?>> getInputProperties() {
		
		HashMap<String, Class<?>> props = new HashMap<String, Class<?>>();
		props.put("name", String.class);
		props.put("age", int.class);
		
		return props;
	}

	public HashMap<String, Class<?>> getOutputProperties() {
		
		HashMap<String, Class<?>> props = new HashMap<String, Class<?>>();
		props.put("result", String.class);
		
		return props;
	}

}
