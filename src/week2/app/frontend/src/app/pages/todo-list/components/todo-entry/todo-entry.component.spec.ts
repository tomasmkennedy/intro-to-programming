import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TodoEntryComponent } from './todo-entry.component';

describe('TodoEntryComponent', () => {
  let component: TodoEntryComponent;
  let fixture: ComponentFixture<TodoEntryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TodoEntryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TodoEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
