import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'pagination',
    templateUrl: './pagination.component.html',
    styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent implements OnInit {
    _page: number;

    @Input()
    get page(): number {
        return this._page;
    }

    set page(value: number) {
        this._page = value;
        this.pageChange.emit(this._page);
    }

    @Input()
    itemsPerPage: number;

    @Input()
    totalCount: number;

    @Output()
    pageChanged: EventEmitter<any> = new EventEmitter();


    @Output()
    pageChange: EventEmitter<any> = new EventEmitter();

    constructor(private route: ActivatedRoute) {

    }

    ngOnInit() {
        if (!this.itemsPerPage) {
            this.itemsPerPage = 10;
        }

        if (!this.totalCount) {
            this.totalCount = 0;
        }
    }

    goToPage(page: number): void {
        this.page = page;

        if (this.page > 1) {
            this.route.params["p"] = this.page;
        } else {
            this.route.params["p"] = null;
        }

        setTimeout(() => {
            this.pageChanged.emit(null);
        }, 0);
    }

    prevPage(): void {
        if (this.page != 1) {
            this.goToPage(this.page - 1)
        }
    }

    nextPage(): void {
        if (this.page != this.pageCount){
            this.goToPage(this.page + 1)
        }
    }

    get pageCount(): number {
        return Math.ceil(this.totalCount / this.itemsPerPage);
    }

    get numberOfPages(): number[] {
        var min = Math.max(1, this.page - 5);
        var max = Math.min(this.page + 5, this.pageCount);

        let pages = [];
        for (var idx = min; idx <= max; ++idx) {
            pages.push(idx);
        }
        return pages;
    }
}