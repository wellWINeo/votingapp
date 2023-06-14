import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { Observable } from 'rxjs';
import { AccessMode } from 'src/app/modules/api/models/access-modes/access-mode';
import { AccessModesService } from 'src/app/modules/api/services/access-modes.service';
import { CvaBase } from 'src/app/modules/shared/cva.base';

@Component({
  selector: 'access-mode-selector',
  templateUrl: './access-mode-selector.component.html',
  styleUrls: ['./access-mode-selector.component.scss'],
})
@UntilDestroy()
export class AccessModeSelectorComponent
  extends CvaBase<number>
  implements OnInit
{
  public modes$: Observable<AccessMode[]> = new Observable<AccessMode[]>();

  override set value(val: number) {
    this.valueControl.setValue(val);
  }
  override get value(): number {
    return this.valueControl.value;
  }

  public valueControl = new FormControl<number>(0, {
    nonNullable: true,
    validators: [Validators.required],
  });

  constructor(private accessModesService: AccessModesService) {
    super();
  }

  ngOnInit(): void {
    this.modes$ = this.accessModesService.get();

    this.valueControl.valueChanges.pipe(untilDestroyed(this)).subscribe(val => {
      this.onTouchedCallback();
      this.onChangeCallback(val);
    })
  }
}
