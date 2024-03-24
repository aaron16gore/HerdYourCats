export class PanelObject {
    title: string = "Placeholder Title";
    label: string = "Placholder Label";
    icon: string = "fa-lightbulb";
    panelAction: () => void;
    
    constructor(icon: string, label: string, description: string, panelAction: () => void) {
        this.icon = icon;
        this.title = label;
        this.description = description;
        this.panelAction = panelAction;
    }
}