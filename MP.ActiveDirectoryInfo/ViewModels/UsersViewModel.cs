using MahApps.Metro.Controls.Dialogs;
using MP.ActiveDirectoryInfo.Extensions;
using MP.ActiveDirectoryInfo.Models;
using MP.Support;
using MP.Support.Logging;
using System;
using System.Collections.ObjectModel;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MP.ActiveDirectoryInfo.ViewModels
{
    public class UsersViewModel : BindableBase
    {
        private readonly IDialogCoordinator _dlgCoord;
        private readonly DialogSettings _dlgSet;

        public ICommand LoadedCmd { get; }
        public ICommand OpenUserCmd { get; }
        public ICommand RefreshCmd { get; }

        public UsersViewModel()
        {
            _dlgCoord = DialogCoordinator.Instance;
            _dlgSet = DialogSettings.Instance;

            LoadedCmd = new RelayCommandAsync(LoadUsersAsync);
            OpenUserCmd = new RelayCommandAsync(OpenUser);
        }

        #region Props

        private string _searchTerms = string.Empty;
        private User _selectedUser = new User();

        private static readonly string stringDomainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;

        public string SearchTerms
        {
            get => _searchTerms;
            set { _searchTerms = value; RaisePropertyChanged(nameof(SearchTerms)); }
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set { _selectedUser = value; RaisePropertyChanged(nameof(SelectedUser)); }
        }

        #endregion Props

        #region Collections

        private ObservableCollection<UserPrincipal> _usersList = new ObservableCollection<UserPrincipal>();

        public ObservableCollection<UserPrincipal> UsersList
        {
            get => _usersList;
            set { _usersList = value; RaisePropertyChanged(nameof(UsersList)); }
        }

        #endregion Collections

        private async Task LoadUsersAsync(object arg)
        {
            var loadingDlg = await _dlgCoord.ShowProgressAsync(this, "Please Wait", "Loading info...", false, _dlgSet.DlgDefaultSet);
            loadingDlg.SetIndeterminate();
            await Task.Run(() =>
            {
                PrincipalContext context = new PrincipalContext(ContextType.Domain);
                UserPrincipal principal = new UserPrincipal(context);
                principal.Enabled = true;
                PrincipalSearcher searcher = new PrincipalSearcher(principal);

                UsersList = searcher.FindAll().Cast<UserPrincipal>()
                    .Where(x => x.Name == SearchTerms)
                    //.Select(x => new SomeUserModelClass
                    //{
                    //    userName = x.SamAccountName,
                    //    email = x.UserPrincipalName,
                    //    guid = x.Guid.Value
                    //})
                    .OrderBy(x => x.Name)
                    .AsEnumerable()
                    .ToObservableCollection();
            });
            await loadingDlg.CloseAsync();
            //try
            //{
            //    var controller = await _dlgCoord.ShowProgressAsync(this, "Please Wait", "Loading info...", false, _dlgSet.DlgDefaultSet);
            //    controller.SetIndeterminate();
            //    UsersList = new ObservableCollection<UserPrincipal>();
            //    using (var principalCtx = new PrincipalContext(ContextType.Domain, stringDomainName))
            //    using (var userPrincipal = new UserPrincipal(principalCtx))
            //    {
            //        UsersList = new PrincipalSearcher(userPrincipal)
            //    }

            //    using (var search = new PrincipalSearcher(userPrincipal))
            //    {
            //        //foreach (UserPrincipal result in search.FindAll().OfType<UserPrincipal>())
            //        //{
            //        //    User user = new User
            //        //    {
            //        //        SamAccountName = result.SamAccountName,
            //        //        UserPrincipalName = result.UserPrincipalName,
            //        //        Name = result.Name,
            //        //        DisplayName = result.DisplayName,
            //        //        GivenName = result.GivenName,
            //        //        Surname = result.Surname,
            //        //        Description = result.Description,
            //        //        Guid = result.Guid,
            //        //        EmailAddress = result.EmailAddress,
            //        //        EmployeeId = result.EmployeeId,
            //        //        LastLogon = result.LastLogon,
            //        //        LastBadPasswordAttemp = result.LastBadPasswordAttempt,
            //        //        Enabled = result.Enabled,
            //        //        BadLogonCount = result.BadLogonCount
            //        //    };
            //        //    UsersFull.Add(user);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log2Text.Instance.ErrorLog(ex.ToString());
            //    throw;
            //}
        }

        private async Task OpenUser(object arg)
        {
            if (arg != null && arg is User user)
            {
                try
                {
                    SelectedUser = user;
                }
                catch (Exception ex)
                {
                    Log2Text.Instance.ErrorLog(ex.ToString());
                    throw;
                }
            }
        }
    }
}