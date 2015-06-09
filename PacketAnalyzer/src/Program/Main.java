package Program;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Scanner;

public class Main 
{
	private static String getOS()
	{
		String result = System.getProperty("os.name");
		return result;
	}
	
	private static void Linux_init()
	{
		try 
		{
			Process proc = Runtime.getRuntime().exec("man tcpdump");
			BufferedReader br = new BufferedReader(new InputStreamReader(proc.getInputStream()));
			
			String recText = "";
			int cnt = 0;
			while((recText = br.readLine()) != null)
			{
				if(recText.contains("Brak podrêcznika"))
				{
					System.out.println("Brak aplikacji Tcpdump. System koñczy dzia³anie!");
					System.exit(1);
				}
				cnt++;
			}
			if(recText == null && cnt == 0)
			{
				System.out.println("Brak aplikacji Tcpdump. System koñczy dzia³anie!");
				System.exit(1);
			}
		} 
		catch (IOException e) 
		{

			e.printStackTrace();
		}
	}
	
	private static String getFileName()
	{
		Scanner sc = new Scanner(System.in);
		String result;
		System.out.println("Podaj nazwê pliku wyjœciowego: ");
		result = sc.next();
		
		if(!result.contains(".ethan"))
		{
			result += ".ethan";
		}
		sc.close();
		return result;
	}
	
	private static String OSname = null;
	
	public static void main(String[] args)
	{
		OSname = getOS();
		
		
		if(OSname.equals("Windows 7"))
		{
			SystemProgram.W7Program();
			
		}
		else if(OSname.equals("Linux"))
		{
			Linux_init();
			String fileName = getFileName();
			new PingSender();
			SystemProgram.LinuxProgram();
			SystemProgram.saveToFile(fileName);
		}
	}
}
