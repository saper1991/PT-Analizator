package Program;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;

public class SystemProgram 
{

	private static List<NetInterface> listOfInterfaces = new ArrayList<NetInterface>();
	
	public static void W7Program()
	{
		System.out.println("Uruchom system w Linuksie!");
	}
	
	public static void LinuxProgram()
	{
		listOfInterfaces = getInterfaces();
		getConsData();
	}
	
	private static String getOurMAC(String name)
	{
		for(NetInterface inter : listOfInterfaces)
		{
			if(inter.getName() == name)
			{
				return inter.getMAC();
			}
		}
		return null;
	}
	
	private static void addConsMAC(String name, String MAC)
	{
		for(NetInterface iface : listOfInterfaces)
		{
			if(iface.getName().contains(name))
			{
				iface.setConsMAC(MAC);
				break;
			}
		}
	}
	
	private static void getConsData()
	{
		String name, ourMAC;
		Process proc = null;

		
		for(int i = 0 ; i < SystemProgram.getCount() ; i++)
		{
			name = SystemProgram.getInterfaceName(i);
			ourMAC = getOurMAC(name);
			
			InputStream is = null;
			
			System.out.print("Skanowanie " + name + "...");
			try 
			{
				String cmd = "tcpdump -ei " + name;
				proc = Runtime.getRuntime().exec(cmd);
				is = proc.getInputStream();
				BufferedReader br = new BufferedReader(new InputStreamReader(is));
				
				String recText = br.readLine(), consMAC;
				recText = br.readLine();
				while((recText = br.readLine()) != null)
				{
					consMAC = recText.substring(50, 67);
					if(consMAC.contains("Broadcast"))
					{
						continue;
					}
					
					if(!consMAC.contains(ourMAC))
					{
						addConsMAC(name, consMAC);
						
						br.close();
						is.close();
						proc.destroy();
						System.out.println(" Gotowe!");
						break;
					}
				}
			} 
			catch (IOException e) 
			{
				e.printStackTrace();
			}	
		}
	}
	
	public static void saveToFile(String fileName)
	{
		try
		{
			PrintWriter pw = new PrintWriter(fileName);
			
			for(int i = 0 ; i < listOfInterfaces.size() ; i++)
			{
				pw.write(listOfInterfaces.get(i).display() + "    true\n");
			}
			
			pw.close();
		} 
		catch (FileNotFoundException e) 
		{
			e.printStackTrace();
		}
	}
	
	public static String getInterfaceName(int i)
	{
		return listOfInterfaces.get(i).getName();
	}
	
	public static int getCount()
	{
		return listOfInterfaces.size();
	}
	
	private static List<NetInterface> getInterfaces()
	{
		BufferedReader br = null;
		String line = null;
		List<NetInterface> results = new ArrayList<NetInterface>();
		
		try 
		{
			Process proc = Runtime.getRuntime().exec("ifconfig");
			br = new BufferedReader(new InputStreamReader(proc.getInputStream()));
			
			while((line = br.readLine()) != null)
			{
				if(line.contains("HWaddr"))
				{
					String name = line.substring(0, 5);
					String MAC = line.substring(38, 55);
					
					results.add(new NetInterface(name, MAC));
				}
			}
		} 
		catch (IOException e) 
		{
			e.printStackTrace();
		}
		
		return results;
	}
}
