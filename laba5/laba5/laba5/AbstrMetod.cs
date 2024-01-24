using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    abstract class AbstrMetod
    {
		abstract public object GetObj
		{
			set; 
		}

		abstract protected void AddNewObj(object obj);
		abstract public void DeleteObj(string name, char type='a');
		abstract public void ShowAllObj();
	}
}
