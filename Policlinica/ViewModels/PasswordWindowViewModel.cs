using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Policlinica.DB;
using Policlinica.Views;

namespace Policlinica.ViewModels;

public partial class PasswordWindowViewModel : ViewModelBase
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IServiceProvider _provider;
    [ObservableProperty] string username;
    [ObservableProperty] string password;
    [ObservableProperty] List<Users> _usersList;
    [ObservableProperty] private Users selectedUsers;
    [ObservableProperty] UserRepository _repository;

    public PasswordWindowViewModel(IServiceProvider provider, UserRepository repository )
    {
        _provider = provider;
        _usersList = repository.GetUsersByTest();
       // _repository = repository;
    }

    [RelayCommand]
    public void StartTest()
    {
        if (SelectedUsers == null)
            return;
        var vm = ActivatorUtilities.CreateInstance<AdminWindowViewModel>(
            _provider,
            SelectedUsers,
            Username);
        var win = _provider.GetRequiredService<AdminWindow>();
        //vm.SetClose(win.Close);
        win.DataContext = vm;
        win.Show();
        // close();

    }
    [RelayCommand]
    public void SaveDB()
    {
        Users user = new Users
        {
            Name = Username,
            Password = Password, 
            Id = SelectedUsers.Id,
          
        };
        _repository.InsertUser(user);
        if (SelectedUsers == null)
            return;
        var vm = _serviceProvider.GetRequiredService<AdminWindowViewModel>();
        var win = _serviceProvider.GetRequiredService<AdminWindow>();
        
        //vm.SetClose(win.Close);
        win.DataContext = vm;
        win.Show();
        //close();
    }
}