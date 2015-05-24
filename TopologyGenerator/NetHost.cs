using System;

public class NetHost
{
    private string deviceName;
    private string residentMAC;
    private string consMAC;

    public NetHost(string deviceName, string residentMAC, string consMAC)
    {
        this.deviceName = deviceName;
        this.residentMAC = residentMAC;
        this.consMAC = consMAC;
    }
}
