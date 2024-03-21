export class MenuItem {
    menuItemRender: string = "";
    menuItemAction: any;

    constructor(menuItemRender: string, menuItemAction: any) {
        this.menuItemRender = menuItemRender;
        this.menuItemAction = menuItemAction;
    }
}