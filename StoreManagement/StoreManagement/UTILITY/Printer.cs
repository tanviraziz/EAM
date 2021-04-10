using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace StoreManagement.UTILITY
{
    class Printer
    {
        public void FillNetworkPrinters(ComboBox combo)
        {
            try
            {
                // Use the ObjectQuery to get the list of configured printers
                ObjectQuery oquery =
                     new ObjectQuery("SELECT * FROM Win32_Printer");

                ManagementObjectSearcher mosearcher =
                    new ManagementObjectSearcher(oquery);

                ManagementObjectCollection moc = mosearcher.Get();

                foreach (ManagementObject mo in moc)
                {
                    System.Management.PropertyDataCollection pdc = mo.Properties;
                    foreach (System.Management.PropertyData pd in pdc)
                    {
                        if ((bool)mo["Network"])
                        {
                            combo.Items.Add(mo[pd.Name]);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void FillLocalPrinters(ComboBox combo)
        {
            try
            {
                PrintDocument prtdoc = new PrintDocument();

                //prt.PrinterSettings.PrinterName returns the name of the Default Printer
                string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;

                //this will loop through all the Installed printers and add the Printer Names to a ComboBox.
                foreach (String strPrinter in PrinterSettings.InstalledPrinters)
                {
                    combo.Items.Add(strPrinter);

                    //This will set the ComboBox Index where the Default Printer Name matches with the current Printer Name returned by for loop
                    if (strPrinter.CompareTo(strDefaultPrinter) == 0)
                    {
                        combo.SelectedIndex = combo.Items.IndexOf(strPrinter);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
