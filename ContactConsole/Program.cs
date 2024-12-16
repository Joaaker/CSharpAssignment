using ContactConsole.Dialogs;
using Shared.Services;
using Shared.Interface;
using Shared.Repositories;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IFileService>(new FileService("data", "contacts.json")) 
    .AddSingleton<IContactRepository, ContactRepository>() 
    .AddSingleton<IContactService, ContactService>() 
    .AddTransient<MenuDialog>()
    .BuildServiceProvider();

var menuDialog = serviceProvider.GetRequiredService<MenuDialog>();
menuDialog.ShowMenu();