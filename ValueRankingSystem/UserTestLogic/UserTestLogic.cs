using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTestLogic
{
    public class UserTestLogic
    {
        // Test Variables

        public bool stringExist;
        
        // Assigns all variables to a definition in order to be called when the user logins
        public static void populateObjectArray()
        {
            Object[] TestTakerInfo = new object[4];
            Test test = new Test();
            TestTakerInfo[0] = test.userName;
            TestTakerInfo[1] = test.firstItem;
            TestTakerInfo[2] = test.secondItem;
            TestTakerInfo[3] = test.thirdItem;
        }
        // Changes the radio buttons based content in array

    }
}
