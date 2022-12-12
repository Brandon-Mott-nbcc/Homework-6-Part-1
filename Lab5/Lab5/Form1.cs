using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {   //William Fox 2022/12/02
        //This program is lab 5, which demonstrates using loops, returning data from functions, and list boxes. There is also more, but I haven't gotten to code it yet.
        public Form1()
        {
            InitializeComponent();
        }
        //Class level constant string to refer to my name
        const string PROGRAMMER = "William Fox";
        //Create a function called GetRandom and have create a random object with no seed value,
        //generate a random number between min and max numbers sent,
        //return a random number from the function
        //stubed with just returning 5
        private int GetRandom(int MIN, int MAX)
        {
            Random rand =   Random();
            int randle = rand.Next(MIN, MAX++);
            return randle;
        }
        //Create the Form_Load event 
        //Add my name to the form text with the constant 
        //hide all the group boxes beside login
        //focus on text box txt code
        //Create the constant variables of MIN and MAX
        //call the GetRandom function to get a random number between 100,000 and 200,000
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += " " + PROGRAMMER;
            grpChoose.Hide();
            grpStats.Hide();
            grpText.Hide();
            txtCode.Focus();
            const int MIN = 100000;
            const int MAX = 200000;
            int rand = GetRandom(MIN, MAX);
            lblCode.Text = rand.ToString();
        }

        //Create the Login button click event 
        //Compare the password entered to the code in the label
        //If incorrect display a message box saying the password is incorrect and that they only have 3 attempts total
        //update the variable of tries by 1 after 
        //Once three attempts have been met, display a different message box stating the account is locked and the program will close
        //Then close the program
        //If they input the correct password disable the login group box and enable the choose group box
        int tries = 1;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            const int ATTEMPTS = 3;
            string attempts = ATTEMPTS.ToString();

            if (txtCode.Text != lblCode.Text && tries < ATTEMPTS)
            {
                string totalTries = tries.ToString();
                MessageBox.Show(totalTries + " incorrect code(s) entered\nTry agian - only " + attempts + " attempts allowed", PROGRAMMER);
                txtCode.Focus();
                txtCode.SelectAll();
                tries++;
            }
            else if (txtCode.Text != lblCode.Text && tries == ATTEMPTS)
            {
                MessageBox.Show(attempts + " attempts to login\nAccount locked - Closing Program",PROGRAMMER);
                this.Close();
            }
            else
            {
                grpChoose.Show();
                grpLogin.Enabled = false;
            }
        }
        //create a function ResetTextGrp 
        //this function will reset the text group box
        //all text boxes will be cleared
        //the check box will be unchecked if checked
        //when this group box is enabled the accept button will be changed join and the cancel button will be on Reset
        private void ResetTextGrp()
        {
            txtString1.Text = "";
            txtString2.Text = "";
            chkSwap.Checked = false;
            lblResults.Text = "";
            this.AcceptButton = btnJoin;
            this.CancelButton = btnReset;
        }
        //Create function ResetStatsGrp 
        //Reset the nud to the minimum value of 10
        //Clear all the labels
        //Clear the items in the numbers list box
        //Set the accept button to be btnGenerate and cancel button to be btnClear
        private void ResetStatsGrp()
        {
            nudTotalNumbers.Value = 10;
            lblSum.Text = "";
            lblMean.Text = "";
            lblOdd.Text = "";
            lstNumbers.Items.Clear();
            this.AcceptButton = btnGenerate;
            this.CancelButton = btnClear;
        }
        //Create the function SetupOption
        //This function will change the visible group box depending on the radio button that is clicked
        //If radText is checked then the Text group box is visible, and if radStats is checked then the Stats group box is visible
        private void SetupOption()
        {
            switch (radText.Checked)
            {
                   case true:
                    grpText.Show();
                    grpStats.Hide();
                 
                    case false:
                    grpText.Hide();
                    grpStats.Show();
                   
            }
        }
        //Now create a checked change event for both of the radio buttons and call the SetupOption for both events
        //also call the function to reset the Text group box that becomes visible
        private void radText_CheckedChanged(object sender, EventArgs e)
        {
            SetupOption();
            ResetTextGrp();
        }
        //for this one you also call the function to reset the stats group box when it becomes visible
        private void radStats_CheckedChanged(object sender, EventArgs e)
        {
            SetupOption();
            ResetStatsGrp();
        }
        //Create the click event for the reset button in the text group box
        //call the ResetTextGrp function to reset the group box
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTextGrp();
        }
        //Create the click event for the clear button in the stats group box
        //Call the ResetStatsGrp function to clear everything in the Stats group box
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetStatsGrp();
        }
        //create the function called Swap that send two strings and returns none
        //This function will swap the two strings in the text group box by swaping the RAM memory location of each string
        //The locations must be swapped once the function ends
        private void Swap(string string1, string string2)
        {
            string swapOne = txtString1.Text;
            string swapTwo = txtString2.Text;
            txtString1.Text = ""+swapTwo;
            txtString2.Text = ""+swapOne;
        }
        //Create the function called CheckInput that sends nothing and returns a boolean
        //This function tests both the textboxes in the group box have data.
        //return true if they do and false if they dont
        private bool CheckInput()
        {
            if(txtString1.Text != "" && txtString2.Text != "")
                return true;
            else
                return false;
            
        }
        //Create the Checked changed event of the Swap Checkbox
        //This event will swap the text boxes if they both have data when the check box is checked
        //To do this we will call the previous two functions: CheckInput and Swap, only executing the Swap function if CheckInput returns true.
        //After the swap, display in the result label "Strings have been swapped!"
        private void chkSwap_CheckedChanged(object sender, EventArgs e)
        {   
            bool verified = CheckInput();
            string string1 = txtString1.Text;
            string string2 = txtString2.Text;
            switch (chkSwap.Checked)
            {
                case true:
                    switch (verified)
                    {
                        case true :
                            Swap(string1, string2);
                            lblResults.Text = "Strings have been swapped!";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        //Creating functions for the constant strings of "first string" and "second string"
        //This could have also been done if made into class level constant strings
        private string First()
        {  string str1 = txtString1.Text;
            const string FIRST = "First string = ";
            return FIRST+str1;
        }
        private string Second()
        {   string str2 = txtString2.Text;
            const string SECOND = "Second string = ";
            return SECOND + str2;
        }
        
        //Create the join button click event 
        //have the result label display what each string says and then combine them with --> in between
        private void btnJoin_Click(object sender, EventArgs e)
        {
            bool verified = CheckInput();
            switch (verified)
            {
                case true:                    
                    string joined = txtString1.Text + " --> " + txtString2.Text;
                    lblResults.Text = First()+"\n"+Second()+"\nJoined = " +joined ;
                    break;
                default:
                    break;
            }

        }
        //Create the Analyze button click event
        //this event will display how many characters are in each string
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            bool verified = CheckInput();
            switch (verified)
            {
                case true:
                    const string CHAR = "Characters = ";
                    int length1 = txtString1.Text.Length;
                    int length2 = txtString2.Text.Length;
                    lblResults.Text = First() + "\n" + CHAR + length1 + "\n" + Second() + "\n" + CHAR + length2;
                    break;
                default:
                    break;
            }

        }
        //Now for coding the Stats group box
        //Create the Generate button click event 
        //Make a random object with the seed value of 733
        //Clear the list box before writing to it 
        //run a "for loop" generating a number between 1000 and 5000, then writing that number to the list box
        //Use the numeric up-down to determine how many numbers are written into the list box
        //This loop does not do any analysis
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            const int MIN = 1000;
            const int MAX = 5000;
            lstNumbers.Items.Clear();
            Random randle = new Random();
            for (int count = 0; count < nudTotalNumbers.Value; count++)
            {
                
                int seedRandom = randle.Next(MIN, MAX + 1);
                lstNumbers.Items.Add(seedRandom);
                int sum = AddList();
                lblSum.Text = sum.ToString("N0");
                double mean = sum /(double)lstNumbers.Items.Count;
                lblMean.Text = mean.ToString("N2");
                int odd = CountOdd();
                lblOdd.Text = odd.ToString("N0");
            }
            
        }
        //Have the above loop working before attempting the functions below.

        //Create function AddList 
        //inside the function create a while loop that adds all the values in the list box together to get the sum
        //You can use the count int for the index number because they update at the same rate.
        private int AddList()
        {
            int counter = 0;
            int sum = 0;
            
            while (counter <lstNumbers.Items.Count)
            {
                int value = Convert.ToInt32(lstNumbers.Items[counter]);
                sum += value;
                counter+;

            }
            return sum;

        }
        //Create the CountOdd function
        //Inside the function count the amount of odd numbers that appear in the list box
        //Use a do while loop to to to add up the total 
        //To test for the odd number I took the mod 2 of the random number, and tested for if the value was == 1.
        private int CountOdd()
        {
            int count = 0;
            int odd = 0;
            do
            {
                int value = (int)lstNumbers.Items[count];
                int valueMod = value % 2;
                switch (valueMod==1)
                {
                    case true:
                        odd++;
                        break;
                    case false:
                        break;

                }
                count++;

            } while (count < lstNumbers.Items.Count);
            return odd;
            
        }

        
    }
}
