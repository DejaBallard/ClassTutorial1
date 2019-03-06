using System;

namespace Version_1_C
{
    [Serializable()] 
    public abstract class clsWork
    {
        private string name;
        private DateTime date = DateTime.Now;
        private decimal value;

        public string Name { get => name; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Value { get => value; set => this.value = value; }

        public clsWork()
        {
            EditDetails();
        }

        public abstract void EditDetails();

        /// <summary>
        /// Dependent on user input, will open up a different inherited form
        /// </summary>
        /// <returns>returns the class of the users input, else null</returns>
        public static clsWork NewWork(int prAnswer)
         {

                 switch (prAnswer)
                 {
                     case 0: return new clsPainting();
                     case 1: return new clsSculpture();
                     case 2: return new clsPhotograph();
                     default: return null;
                 }
         }

        /// <summary>
        /// Overiding to string to display name and date
        /// </summary>
        /// <returns>name and date of artist's work</returns>
        public override string ToString()
        {
            return Name + "\t" + Date.ToShortDateString();  
        }
    }
}
