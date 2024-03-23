export class PanelObject {
    title: string = "Placeholder Title";
    content: string = "Placholder Content";
    icon: string = "fa-lightbulb";
    destination: string = "/stand-up";
    
    constructor(icon: string, title: string, content: string, destination: string) {
        this.icon = icon;
        this.title = title;
        this.content = content;
        this.destination = destination;
    }
}