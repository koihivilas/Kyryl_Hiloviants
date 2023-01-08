using SeleniumHomeTaskV4_2.PageObjects;

namespace SeleniumHomeTaskV4_2
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public void Test1()
        {
            var loginPage = new LoginPageObject(_webDriver);
            loginPage.EnterUsername();
            loginPage.EnterPassword();
            SaveWorkShiftsPageObject saveWorkShiftsPage = loginPage.Login().GoToAdminPanel().GoToWorkShiftsPage().AddWorkShift();
            saveWorkShiftsPage.EnterShiftName();
            saveWorkShiftsPage.SetFromTime();
            saveWorkShiftsPage.SetToTime();
            saveWorkShiftsPage.AssignEmployee();
            WorkShiftsPageObject WorkShiftsPage = saveWorkShiftsPage.SaveWorkShift();
            WorkShiftsPage.CheckNewRow();
            WorkShiftsPage.SelectNewRow();
            var res = WorkShiftsPage.DeleteSelectedRows().Confirm().CheckDeletedRow();

            Assert.IsTrue(res);
        }
    }
}