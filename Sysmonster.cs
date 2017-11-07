using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;

// C:\Windows\Microsoft.Net\Framework\v4.0.30319\csc.exe SysMonster.cs
// RunAs Administrator
// Very Basic Way to Get Sysmon Logs Off A Box.

public class Program
{
	
	public static void Main()
	{
		EventLogWatcher watcher = new EventLogWatcher(@"Microsoft-Windows-Sysmon/Operational");
		
		// Liste For EventRecordWritten
        // When this event happens, the callback method
        // (EventLogEventRead) is called.
		
        watcher.EventRecordWritten +=
            new EventHandler<EventRecordWrittenEventArgs>(
                EventLogEventRead);
		
		
        // Activate the subscription
        watcher.Enabled = true;
		
		
		while (true)
        {
            // Wait for events to occur. 
            System.Threading.Thread.Sleep(10000);
        }
		
	}
	
	// Callback method that gets executed when an event is
	// reported to the subscription.
	public static void EventLogEventRead(object obj,
			EventRecordWrittenEventArgs arg)
			{
				Console.WriteLine("{0}, {1}",arg.EventRecord.Id, arg.EventRecord.FormatDescription());
				//Obviously Do Some JSON stuff/Batch/Forwarding etc..
				
			}
}
