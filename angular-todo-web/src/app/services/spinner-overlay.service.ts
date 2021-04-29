import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { Injectable } from '@angular/core';
import { defer, NEVER } from 'rxjs';
import { finalize, share } from 'rxjs/operators';
import { SpinnerOverlayComponent } from './../components/spinner-overlay/spinner-overlay.component';

@Injectable({
  providedIn: 'root',
})
export class SpinnerOverlayService {
  //The overlay package provides a way to open floating panels on the screen.
  private overlayRef: OverlayRef = undefined;

  constructor(private readonly overlay: Overlay) { }

  /*
  *A solution I found to avoid concurrency issue and, in the same time,
  *avoiding having a complexe code for managing concurency is to use RxJs with ‘share’ operator.
  *The solution is to implement an observable using ‘NEVER’ observable constant in the SpinnerOverlayService.
  *Once the fisrt subscriber will subscribe the observable, thanks to ‘defer’, the spinner overlay will be displayed.
  *And the spinner overlay will stay displayed as long as the observable is subscribed thanks to ‘NEVER’ which emits no items to the Observer and never completes.
  *In row number 34, the statement ‘.pipe(share())’ returns a new Observable that multicasts (shares) the original Observable.
  *It means that if another subriber subscribe to the observable (while it is already subscibed) the statement ‘this.show()’ will not be executed a second time.
  *It also means that in order to go through the ‘finalize’ step, all subscribers need to unsubscribe the observable.
  */
  public readonly spinner$ = defer(() => {
    this.show();
    return NEVER.pipe(
      finalize(() => {
        this.hide();
      })
    );
  }).pipe(share());

  private show(): void {
    // Hack avoiding `ExpressionChangedAfterItHasBeenCheckedError` error
    Promise.resolve(null).then(() => {
      this.overlayRef = this.overlay.create({
        positionStrategy: this.overlay
          .position()
          .global()
          .centerHorizontally()
          .centerVertically(),
        hasBackdrop: true,
      });
      this.overlayRef.attach(new ComponentPortal(SpinnerOverlayComponent));
    });
  }

  private hide(): void {
    this.overlayRef.detach();
    this.overlayRef = undefined;
  }
}