import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoadingSpinnerService } from './loading-spinner.service';
import { finalize } from 'rxjs';

export const loadingSpinnerInterceptor: HttpInterceptorFn = (req, next) => {
  const loadingSpinnerService = inject(LoadingSpinnerService);
  loadingSpinnerService.show();

  return next(req).pipe(
    finalize(() => {
      loadingSpinnerService.hide();
    })
  );
};
