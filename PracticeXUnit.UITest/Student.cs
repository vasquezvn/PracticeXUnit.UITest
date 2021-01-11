using System;
using System.Linq;

namespace PracticeXUnit.UITest
{
    class Student : IEquatable<Student>
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string programme { get; set; }
        public string[] courses { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Student);
        }

        public bool Equals(Student other)
        {
            if (other == null)
            {
                return false;
            }
            return this.id.Equals(other.id)
                && this.firstName.Equals(other.firstName)
                && this.lastName.Equals(other.lastName)
                && this.email.Equals(other.email)
                && this.programme.Equals(other.programme)
                && this.courses.SequenceEqual<string>(other.courses);
        }
    }
}
