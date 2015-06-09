package Program;

public class NetInterface 
{
	private String name = null;
	private String MAC = null;
	private String consMAC = null;
	
	public NetInterface(String name, String MAC)
	{
		this.name = name;
		this.MAC = MAC;
	}
	
	public String getMAC()
	{
		return MAC;
	}
	
	public String getName()
	{
		return name;
	}
	
	public String display()
	{
		return name + "   " + MAC + "   " + consMAC;
	}
	
	public void setConsMAC(String value)
	{
		this.consMAC = value;
	}
}
