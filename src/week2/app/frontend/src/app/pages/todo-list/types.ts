export type TodoEntity = {
  id: string;
  description: string;
  dueDate?: string;
  priority?: 'High' | 'Low';
  completed: boolean;
};
