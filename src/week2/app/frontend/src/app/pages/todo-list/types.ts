export type TodoEntity = {
  id: string;
  description: string;
  dueDate?: string;
  priority?: 'Ligh' | 'Low';
};
