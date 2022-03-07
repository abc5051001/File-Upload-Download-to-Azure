class extract
{
    static void Main(string[] args)
    {   
        string file = "C:\Users\llol1\Desktop Profit.txt";
        FileInfo oFileInfo = new FileInfo(strFilename);

        if (oFileInfo != null || oFileInfo.Length == 0)
        {
        MessageBox.Show("My File's Name: \"" + oFileInfo.Name + "\"");
        // For calculating the size of files it holds.
        MessageBox.Show("myFile total Size: " + oFileInfo.Length.ToString());
        }

        if (!oFileInfo.Exists)
        {
            throw new FileNotFoundException("The file was not found.", FileName);
        }

        DateTime dtCreationTime = oFileInfo.CreationTime;
        MessageBox.Show("Date and Time File Created: " + dtCreationTime.ToString());

        MessageBox.Show("myFile Extension: " + oFileInfo.Extension);
    }               
}