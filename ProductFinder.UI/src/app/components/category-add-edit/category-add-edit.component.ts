import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CoreService } from 'src/app/core/core.service';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-add-edit',
  templateUrl: './category-add-edit.component.html',
  styleUrls: ['./category-add-edit.component.css']
})
export class CategoryAddEditComponent implements OnInit {
  categoryForm: FormGroup;

  constructor(private _formBuilder: FormBuilder, 
    private _categoryService: CategoryService, 
    private _dialogRef: MatDialogRef<CategoryAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _coreService: CoreService,

  ) {
    this.categoryForm = this._formBuilder.group({
      name: '',
    })
  }
  ngOnInit(): void {
    this.categoryForm.patchValue(this.data);
  }

  onFormSubmit() {
    if(this.categoryForm.valid) {
      if(this.data) {
        this._categoryService
        .updateCategory(this.data.categoryId, this.categoryForm.value)
        .subscribe({
          next: (val: any) => {
            
            this._coreService.openSnackBar('Category was updated successfully');
            this._dialogRef.close(true);
  
          },
          error: () => {
            console.log("Error occured.");
          }
        });

      } else{
        this._categoryService
        .addCategory(this.categoryForm.value)
        .subscribe({
          next: (value: any) => {
            
            this._coreService.openSnackBar('Category was added successfully');
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
