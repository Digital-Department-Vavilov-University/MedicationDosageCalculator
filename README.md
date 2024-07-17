# MedicationDosageCalculator
Расчет дозировки лекарств - это простое приложение на Windows Forms, разработанное для ветеринарных клиник и владельцев домашних животных. Оно позволяет рассчитывать дозировку лекарств для различных животных на основе их веса. Результаты расчетов сохраняются в таблице для последующего анализа.
## Функциональные возможности

- **Ввод данных животного**: Позволяет вводить ID клиента, кличку животного, вес, возраст и наименование лекарства.
- **Расчет дозировки**: Рассчитывает дозировку лекарства на основе введенного веса животного и дозировки на килограмм.
- **Отображение результатов**: Сохраняет результаты расчетов в таблице для удобного просмотра и анализа.
- **Сохранение таблицы**: Возможность сохранить данные таблицы в CSV файл.
- **Загрузка таблицы**: Возможность загрузить данные из CSV файла в таблицу.
  ## Описание и код программы
Главный экран

  ![Главный экран](https://github.com/user-attachments/assets/c388fc19-34c6-4001-8417-f46b7f31fe36)

  Ввод данных
  
![Ввод данных](https://github.com/user-attachments/assets/9a03f16c-e9e7-469c-979e-1e6a7a103b82)

Сохранение данных
![Сохранение данных](https://github.com/user-attachments/assets/c26887e9-b7c4-4f86-9632-0cf8ef67b77f)

Открытие данных

![Открытие данных](https://github.com/user-attachments/assets/716479dd-964e-4845-b3e4-1501a371da80)

Метод - сохранение файла с данными 
'''

             private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    // Записываем заголовки столбцов
                    for (int i = 0; i < dgvResults.Columns.Count; i++)
                    {
                        writer.Write(dgvResults.Columns[i].HeaderText);
                        if (i < dgvResults.Columns.Count - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine();

                    // Записываем строки данных
                    for (int i = 0; i < dgvResults.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvResults.Columns.Count; j++)
                        {
                            writer.Write(dgvResults.Rows[i].Cells[j].Value);
                            if (j < dgvResults.Columns.Count - 1)
                            {
                                writer.Write(",");
                            }
                        }
                        writer.WriteLine();
                    }
                }
            }
        }
'''


 ## Используемые технологии

- **Язык программирования**: C#
- **Платформа**: .NET Framework
- **Интерфейс**: Windows Forms
