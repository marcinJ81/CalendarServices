export class endPointWebApi{
    private hairServiceUrl: string;
    private typeServiceUrl: string;

    constructor() {
        this.hairServiceUrl = 'http://localhost:5000/api/HairDresserServices';
        this.typeServiceUrl = 'http://localhost:5000/api/HairDresserServices/TypeServices';
    }

    public get HairServiceUrl() : string {
        return this.hairServiceUrl;
    }

    public get TypeServiceUrl() :string {
        return this.typeServiceUrl;
    }
}