import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerFollowersComponent } from './customer-followers.component';

describe('CustomerFollowersComponent', () => {
  let component: CustomerFollowersComponent;
  let fixture: ComponentFixture<CustomerFollowersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomerFollowersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerFollowersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
