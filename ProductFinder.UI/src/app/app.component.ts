import { Component, OnInit, ViewChild} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProdAddEditComponent } from './components/prod-add-edit/prod-add-edit.component';
import { Product } from './models/product';
import { ProductService } from './services/product.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { CoreService } from './core/core.service';
import { Category } from './models/category';
import { CategoryService } from './services/category.service';
import { CategoryAddEditComponent } from './components/category-add-edit/category-add-edit.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent implements OnInit{
  title = 'ProductFinder.UI';
  products: Product[] = [];
  categories: Category[] = [];
  
  //From table
  displayedColumns: string[] = [
    'productId', 
    'name', 
    'description', 
    'categoryId',
    'action',
  ];
  displayedColumnsCategory: string[] = [
    'categoryId',
    'name',
    'action',
  ]
  dataSource!: MatTableDataSource<any>;
  dataSourceCategory!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  


  
  constructor(
    private _productService: ProductService, 
    private _categoryService: CategoryService,
    private _dialog: MatDialog,
    private _coreService: CoreService,
  ){}

  ngOnInit() : void {
    this.getProductList();
    this.getCategoryList();
    /*this._productService.
    getProducts().
    subscribe((result: Product[]) => (this.products = result));*/
  }  

  openAddEditEmpForm(){
    const dialogRef = this._dialog.open(ProdAddEditComponent);
    dialogRef.afterClosed().subscribe({
      next: (value) => {
        if(value) {
          this.getProductList();
        }
      }
    });
  }

  openAddEditCategoryForm(){
    const dialogRef = this._dialog.open(CategoryAddEditComponent);
    dialogRef.afterClosed().subscribe({
      next: (value) => {
        if(value) {
          this.getCategoryList();
        }
      }
    });
  }

  getProductList() {
    this._productService.getProducts().subscribe({
      next: (result) => {
        this.dataSource = new MatTableDataSource(result);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;

      },
      error: console.log,
    })

  }

  getCategoryList() {
    this._categoryService.getCategory().subscribe({
      next: (result) => {
        this.dataSourceCategory = new MatTableDataSource(result);
        this.dataSourceCategory.sort = this.sort;
        this.dataSourceCategory.paginator = this.paginator;

      },
      error: console.log,
    })

  }
  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  applyFilterCategory(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSourceCategory.filter = filterValue.trim().toLowerCase();

    if (this.dataSourceCategory.paginator) {
      this.dataSourceCategory.paginator.firstPage();
    }
  }

  deleteProduct(id: number){
    this._productService.deleteProducts(id).subscribe({
      next: (result) => {
        this._coreService.openSnackBar('Product was deleted.');
        this.getProductList();
      },
      error: console.log,
    })
  }

  deleteCategory(id: number){
    this._categoryService.deleteCategory(id).subscribe({
      next: (result) => {
        this._coreService.openSnackBar('Category was deleted.');
        this.getCategoryList();
      },
      error: console.log,
    })
  }

  openEditForm(data: any){
    const dialogRef = this._dialog.open(ProdAddEditComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (value) => {
        if(value){
          this.getProductList();
        }
      }
    });
    
  }

  openCategoryEditForm(data: any){
    const dialogRef = this._dialog.open(CategoryAddEditComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (value) => {
        if(value){
          this.getCategoryList();
        }
      }
    });
    
  }
  
}


