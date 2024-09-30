import { Component } from '@angular/core';
import { NumberService } from '../../services/number.service';
import { FormsModule } from '@angular/forms';
import { catchError, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent {

  number: number;
  text: string;

  constructor(private numberService: NumberService) {}

  onSubmit() {
    
    this.numberService.getStringFromNumber(this.number)
      .pipe(catchError(this.handleError))
      .subscribe(answer => {
        this.text = answer.text;
        console.log(answer.text);
      });
  }

  private handleError(error: HttpErrorResponse) {
    return throwError(() => {
      console.log(error)
      alert("Please input a valid 2 decimal place number!")
    });
  }
}
