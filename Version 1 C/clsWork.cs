using System;

namespace Version_1_C
{
    [Serializable()] 
    public abstract class clsWork
    {
        protected string _Name;
        protected DateTime _Date = DateTime.Now;
        protected decimal _Value;

        public clsWork()
        {
            EditDetails();
        }

        public abstract void EditDetails();

        /// <summary>
        /// Dependent on user input, will open up a different inherited form
        /// </summary>
        /// <returns>returns the class of the users input, else null</returns>
        public static clsWork NewWork()
         {
             char lcReply;
             InputBox inputBox = new InputBox("Enter P for Painting, S for Sculpture and H for Photograph");
             //inputBox.ShowDialog();
             //if (inputBox.getAction() == true)
             if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 lcReply = Convert.ToChar(inputBox.getAnswer());

                 switch (char.ToUpper(lcReply))
                 {
                     case 'P': return new clsPainting();
                     case 'S': return new clsSculpture();
                     case 'H': return new clsPhotograph();
                     default: return null;
                 }
             }
             else
             {
                 inputBox.Close();
                 return null;
             }
         }

        /// <summary>
        /// Overiding to string to display name and date
        /// </summary>
        /// <returns>name and date of artist's work</returns>
        public override string ToString()
        {
            return _Name + "\t" + _Date.ToShortDateString();  
        }
        
        /// <summary>
        /// Get the name of the artist's work
        /// </summary>
        /// <returns>Name of artist's work</returns>
        public string GetName()
        {
            return _Name;
        }

        /// <summary>
        /// Get the date of the artist's work
        /// </summary>
        /// <returns>date of artist's work</returns>
        public DateTime GetDate()
        {
            return _Date;
        }

        /// <summary>
        /// Get value of artist's work
        /// </summary>
        /// <returns>Value of artist's work</returns>
        public decimal GetValue()
        {
            return _Value;
        }
    }
}
