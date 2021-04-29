namespace ConcentricDemoProj.TestData
{
    class PracticeForm
    {
        private string _firstName;
        private string _lastName;
        private string _mobile;
        private string _gender;

        public static PracticeForm Create(string firstName, string lastName, string mobile, string gender)
        {
            return new PracticeForm(firstName, lastName, mobile, gender);
        }
        private PracticeForm(string firstName, string lastName, string mobile, string gender)
        {
            _firstName = firstName;
            _lastName = lastName;
            _mobile = mobile;
            _gender = gender;
        }
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public string Mobile => _mobile;
        public string Gender => _gender;
    }
}
