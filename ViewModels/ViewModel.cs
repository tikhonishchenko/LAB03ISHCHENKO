using LAB03ISHCHENKO.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace LAB03ISHCHENKO.ViewModels
{
    internal class ViewModel
    {
        public static bool CalculateAge(DateTime? birthDate)
        {
            if (birthDate != null)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Value.Year;
                if (birthDate > today.AddYears(-age)) age--;
                try
                {
                    if (age > 135)
                    {
                        throw new AgeTooLowException("Та ти точно не такий старий, давай пиши справжній");
                    }
                    else if (age < 0)
                    {
                        throw new AgeTooHighException("Та ти точно не такий молодий, давай пиши справжній");
                    }
                    else
                    {
                        if (birthDate.Value.Month == today.Month && birthDate.Value.Day == today.Day)
                            MessageBox.Show("З днем народження!");
                        return true;
                    }
                }
                catch (AgeTooLowException atl)
                {
                    MessageBox.Show("AgeTooLowException");
                }
                catch (AgeTooHighException ath)
                {
                    MessageBox.Show("AgeTooHighException");
                }
            }
            return false;
        }
    }
}
