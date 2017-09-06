import { ILoadable } from './index';

export class LoadableComponent implements ILoadable{
    public loading: boolean;

    constructor(loading: boolean = false) {
        this.loading = loading;
    }
}
