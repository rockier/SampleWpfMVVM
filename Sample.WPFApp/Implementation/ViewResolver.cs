using Sample.Entities.Interfaces;
using System;
using System.Windows;

namespace Sample.WPFApp.Implementation
{
    public class ViewResolver : IViewResolver
    {
        private Window GetWindow(string formName)
        {
            try
            {
                var form = Type.GetType(string.Format("Sample.WPFApp.Forms.{0}", formName), true);
                if (form != null)
                {
                    var o = (Activator.CreateInstance(form));
                    if (o is Window)
                    {
                        return ((Window)o);
                    }
                }
            }
            catch (TypeLoadException)
            {
                return null;
            }

            return null;
        }

        public bool Show(string formName)
        {
            var win = GetWindow(formName);
            if (win != null)
            {
                win.Show();
                return true;
            }

            return false;
        }

        public bool ShowModal(string formName)
        {
            var win = GetWindow(formName);
            if (win != null)
            {
                win.ShowDialog();
                return true;
            }

            return false;
        }

        public bool ShowModal(string formName, int id)
        {
            var win = GetWindow(formName);
            if (win != null)
            {
                win.ShowDialog();
                return true;
            }

            return false;
        }
    }
}
