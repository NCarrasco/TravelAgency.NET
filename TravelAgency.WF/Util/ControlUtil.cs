using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgency.WF.Util
{
    public class ControlUtil
    {
        public static void DisableValidation(ControlCollection controls)
        {
            foreach (var c in controls)
            {
                var tb = c as TextBox;
                if (tb != null)
                {
                    tb.Enabled = false;
                    tb.CausesValidation = false;
                }
                if (c is UserControl)
                {
                    UserControl uc = c as UserControl;
                    DisableValidation(uc.Controls);
                }
            }
        }
    }
}