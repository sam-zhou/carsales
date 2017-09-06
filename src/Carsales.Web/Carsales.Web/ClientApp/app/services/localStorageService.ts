import { Injectable } from '@angular/core';

@Injectable()
export class LocalStorageService {

    public set(key: string, data: any): void {
        localStorage.setItem(key, JSON.stringify(data));
    }

    public get(key: string): any {
        let stringData = localStorage.getItem(key);
        if (stringData) {
            return JSON.parse(stringData);
        }
        return null;
    }

    public clear(key: string): void {
        localStorage.removeItem(key);
    }
}