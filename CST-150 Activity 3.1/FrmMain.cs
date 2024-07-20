/*
 * Lindsey DeDecker
 * CST-150
 * Activity 3
 * 7.20.24
 */


namespace CST_150_Activity_3._1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            //Set the properties for the selectFileDialog control
            //Define the initial directory that is shown
            selectFileDialog.InitialDirectory = Application.StartupPath + @"Data";
            //Set the title of open file dialog
            selectFileDialog.Title = "Browse Txt Files";
            //DefaultExt is only used when "All Files" is selected
            //from the filter box and no extentsion is sepecified by the user
            selectFileDialog.DefaultExt = "Txt";
            selectFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            //When the form is initialized make sure the lblResults and lblSelectedFile are not visible
            lblResults.Visible = false;
            lblSelectedFile.Visible = false;

            //Make sure the combobox is not visible
            cmbSelectRow.Visible = false;
            lblSelectRow.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void lblSelectedFile_Click(object sender, EventArgs e)
        {

        }

        private void BtnReadFileClickEvent(object sender, EventArgs e)
        {

            //Make sure the label is visible 
            lblResults.Visible = true;
            //Since the combobox is populated turn visibility to true
            cmbSelectRow.Visible = true;
            lblSelectRow.Visible = true;


            //Declare and initialzie variables
            string txtFile = "";
            string dirLocation = "";
            const int PadSpace = 20;
            string header1 = "Type", header2 = "Color", header3 = "Qty";
            string headerLine1 = "----", headerLine2 = "----", headerLine3 = "----";

            //Use this int to dynamically populate the combobox
            int numberRow = 1;
            //Variables for qty update
            int qtyValue = -1;
            int rowSelected = -1;


            //Once the button is clicked - show file dialog
            if (this.selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read in the text file that was selected
                txtFile = this.selectFileDialog.FileName;
                //Get the path of the file plus the filename
                dirLocation = Path.GetFullPath(selectFileDialog.FileName);
                //show the selcted file and path in the label
                lblSelectedFile.Text = txtFile;
                //Make sure to make this label visible
                lblSelectedFile.Visible = true;

            }
            

            //Read all the lines into a one dimentional string array
            string[] lines = File.ReadAllLines(txtFile);

            //Get the row that is selected from the combobox 
            //first ensure there is a selection and the combobox is not blank
            rowSelected = SelectedRow();
            if (rowSelected >= 0)
            {
                //Get the qty from the row selectedGetQty()
                qtyValue = GetQty(lines, rowSelected);
                //Now we can inc the qty and store it back to the file
                IncDisplayQty(lines, rowSelected, qtyValue, txtFile);
            }

            //Populate a lable with the array and make sure the label is cleared out before we start
            lblResults.Text = "";
            
            foreach (string line in lines)
            {
                // Had to add this check as the program was only reading selectedRow when the Read File button is being clicked
                //this caused the addition of 8 more lines each time.

                if (cmbSelectRow.Items.Count <= lines.Length)
                {
                    //Dynamically Populate the combobox
                    cmbSelectRow.Items.Add(numberRow);

                    //Inc to next row
                    numberRow++;
            }
                    


                //Split each line into an array of elements
                string[] inventoryList = line.Split(", ");
                //Iterate through each element in the array using a for loop
                for (int i = 0; i < inventoryList.Length; i++)
                {
                    //Call the method to convert all text to lower case
                    ConvertLowerCase(inventoryList[i]);
                }
                //Meed a new line after each iteration to show next line
                lblResults.Text += "\n";
            }
            

            

           

        }


        //-------------------------------------------
        //first Method
        //-------------------------------------------

        ///<summary>
        ///Convert input to all lower case characted then sent the results to be displayed
        /// </summary>
        ///<param name="TextToConvert"></param>

        private void ConvertLowerCase(String textToConvert)
        {
            //Convert all text to lwoer case using the argument
            ResultsToLabel(textToConvert.ToLower());
        }

        ///<summary>
        ///Print results to label
        /// </summary>
        ///<param name="Results"></param>"

        private void ResultsToLabel(string results)
        {
            //Declare and initialize constant
            const int PadSpace = 20;
            //Display each element using proper spacing
            lblResults.Text += results.PadRight(PadSpace);

        }
        ///<summary>
        ///Return the row selected in the pull down
        /// </summary>
        /// ///<return></return>
        
        private int SelectedRow()
        {
            //Make sure there is a row selected
            if(cmbSelectRow.SelectedIndex >=0)
            {
                //Return the int of the row selected
                return cmbSelectRow.SelectedIndex;
            }
            else
            {
                //Return a flag of -1 so we know there was not selected row
                return -1;
            }
        }

        ///<summary>
        ///Get the Qty value from the selected row
        /// </summary>
        /// <param naem ="lines"></param>
        /// <param name="selectedRow"></param>"
        /// <returns></returns>
        
        private int GetQty(string[] lines, int selectedRow)
        {
            //Declareand initialize
            int qty = -1; //This way we know if there was an error
            //Interate through the array until the selected row is found
            //since we know the exact number of times to iterate through the array which loop is the best to use? None, don't need one, select row by index
            for(int x = 0; x < lines.Length; x++)
            {
                if (x == selectedRow)
                {
                    string[] invRow = lines[x].Split(",");
                    //Now pull out the qty.
                    //Use exception handling to parse string to int
                    try
                    {
                        //Convert string representation for a number to its signed integer
                        qty = int.Parse(invRow[2].Trim());
                        return qty;
                    }
                    catch (FormatException e)
                    {
                        //Show an exception message
                        lblResults.Text = e.Message;
                    }
                }
            }
            //If there are any exceptions, return -1
            return qty;
        }

        ///<summary>
        ///Inc qty value, build the string for file, save to file
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="invRowToUpdate"></param>
        /// <param name="qty"></param>
        /// <param name="txtFile"></param>
        
        private void IncDisplayQty(string[] lines, int invRowToUpdate, int qty, string txtFile)
        {
            //Declare and initialize
            string updateLine = "";

            //First inc qty
            qty++;

            //Now we need to update the qty in the array
            //First we need to split up the row so we can update the array
            string[] invRow = lines[invRowToUpdate].Split(",");
            //Then we can update the elemtn in the string array
            invRow[2] = qty.ToString();
            //We need to build the string to store in the Lines array
            updateLine = invRow[0].Trim() + ", " + invRow[1].Trim() + ", " + invRow[2].Trim();
            //now update the lines array
            lines[invRowToUpdate] = updateLine;
            //Now update the text file
            File.WriteAllLines(txtFile, lines);

        }
    }
}
