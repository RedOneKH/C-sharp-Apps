# master-page-asp
MasterPages in ASP.NET gives to programmer an easy way to create web-site which has several pages, which has some common part (example a menu)

1. Create an new empty ASP.Net project
2. Add an MasterPage and three Subpages (catsPage, dogsPage, Default) to your project
3. Add some content (text and pictures to all Subpages) the Default is the MainPage
4. Add a menu to the Master
  * the menu has links: "MainPage", "Cats", "Dogs"
  * Creating the menu.  You can create the menu like this:
    * Drag Menu-Control to you page-header
    * In DesignMode click the arrow in Menu and choose EditMenuItems... ->Click the plus-sign (add root item)
    * In the Text-property write text(ex. MainPage) and in the NavigateUrl choose the the subpage
    * Click the plus-sign again to add the next one ...
