using ContactConsole.Dialogs;
using Shared.Services;
using Shared.Interface;


/* Detta är genererat av ChatGPT o1 
* Denna kod skapar instanser av FileService, ContactService och MenuDialog
* och hanterar Dependency injection mellan dessa filer. */
IFileService fileService = new FileService();
IContactService contactService = new ContactService(fileService);
var consoleMenu = new MenuDialog(contactService);

consoleMenu.ShowMenu();