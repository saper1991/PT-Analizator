package Program;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class PingSender extends Thread implements Runnable
{
	private Process arp = null;
	private Process[] pings = null;
	private List<String> IP = null;
	
	public PingSender()
	{
		IP = new ArrayList<String>();
		
		try 
		{
			arp = Runtime.getRuntime().exec("arp -a");
			BufferedReader br = new BufferedReader(new InputStreamReader(arp.getInputStream()));
			
			String recArp, capIP = "";
			while((recArp = br.readLine()) != null)
			{
				for(int i = 3 ; i < recArp.length() ; i++)
				{
					if(recArp.charAt(i) == ')')
					{
						break;
					}
					else
					{
						capIP += recArp.charAt(i);
					}
				}
				
				IP.add(capIP);
				capIP = "";
			}
			
			pings  = new Process[IP.size()];
			br.close();
			
		} 
		catch (IOException e) 
		{
			e.printStackTrace();
		}
		
		start();
	}
	
	public void run()
	{
		for(int i = 0 ; i < IP.size() ; i++)
		{
			String cmd = "ping " + IP.get(i);
			try 
			{
				pings[i] = Runtime.getRuntime().exec(cmd);
			} 
			catch (IOException e) 
			{
				e.printStackTrace();
			}
		}
	}
}
