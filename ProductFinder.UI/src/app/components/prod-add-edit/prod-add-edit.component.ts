import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CoreService } from 'src/app/core/core.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-prod-add-edit',
  templateUrl: './prod-add-edit.component.html',
  styleUrls: ['./prod-add-edit.component.css']
})
export class ProdAddEditComponent implements OnInit{
  productForm: FormGroup;

  constructor(private _formBuilder: FormBuilder, 
    private _productService: ProductService, 
    private _dialogRef: MatDialogRef<ProdAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _coreService: CoreService,

  ) {
    this.productForm = this._formBuilder.group({
      name: '',
      description: '',
      categoryId: 1
    })
  }
  ngOnInit(): void {
    this.productForm.patchValue(this.data);
  }

  onFormSubmit() {
    if(this.productForm.valid) {
      if(this.data) {
        this._productService
        .updateProducts(this.data.productId, this.productForm.value)
        .subscribe({
          next: (val: any) => {
            
            this._coreService.openSnackBar('Product was updated successfully');
            this._dialogRef.close(true);
  
          },
          error: () => {
            console.log("Error occured.");
          }
        });

      } else{
        this._productService
        .addProducts(this.productForm.value)
        .subscribe({
          next: (value: any) => {
            
            this._coreService.openSnackBar('Product was added successfully');
            this._dialogRef.close(true);
  
          },
          error:() => {
            console.log("error occured.");
          }
        });

      }
      
    }
  }

}
