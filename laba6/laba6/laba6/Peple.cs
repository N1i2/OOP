using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyException;

namespace MyClass
{
    class Peple
    {
        public Peple(string name)
        {
            FullName = name;
        }

        private string fullName;

		public string FullName
		{
			get { return fullName; }
			set 
			{
				string[] name=value.Split(' ');

				if (name.Length != 3)
					throw new FullNameException(value);

				for (int i = 0; i < 3; i++)
				{
					if (name[i].Length < 2)
						throw new TooShortNameException(value);

					if ((int)((name[i])[0]) < 65 || (int)((name[i])[0]) > 90)
						throw new HightRigistryException(value);
				}

				for (int i = 0; i < 3; i++)
				{
                    for (int j = 1; j < name[i].Length; j++)
                    {
                        if ((int)((name[i])[j]) >= 65 && (int)((name[i])[j]) <= 90)
                            throw new LowRigistryException(value);

                        if ((int)((name[i])[j]) < 97 || (int)((name[i])[j]) > 122)
                         throw new InvalidSimbleException(value);
                    }
                }

				fullName = value;
			}
		}
	}
}
