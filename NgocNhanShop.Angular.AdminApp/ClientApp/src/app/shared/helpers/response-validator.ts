import { FormGroup } from "@angular/forms";
import { ResponseError } from "src/app/models/response-error";

export function ResponseValidator(listError: ResponseError[],){
    formGroup: FormGroup;
    listError.forEach(element => {
        const control = this.formGroup.controls[element.key];
        if (element.value != null) {
            control.setErrors({ confirmedValidator: true });
        } else {
            control.setErrors(null);
        }
    });
}