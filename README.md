# BloodManager

<p>O projeto Blood Manager foi realizado com o intuito de melhorar minhas habilidades com a linguagem de programação C# e com todo o seu ecossistema.</p>

### Pilha de tecnologias

- .NET 8.0
- Entity Framework Core 8.0

### Regras de negócio

- [x] Um doador deve possuir um e-mail único no banco de dados;
Menor de idade não pode doar, mas pode ter cadastro;
- [x] O doador deve pesar no mínimo 50kg; 
- [x] Mulheres só podem doar de 90 em 90 dias;
- [x] Homens só podem doar de 60 em 60 dias;
- [x] A quantidade de ML de sangue doados deve ser entre 420 e 470 ML.
- [ ] Deve realizar aumento do estoque de sangue ao realizar doação 

### Tecnologias e conceitos aplicados

- [x] Realizar documentação com o Swagger
- [x] Realizar com um banco de dados de verdade (não em memória)
- [x] Separação de serviços de leitura e escrita (CQRS) com padrão Mediator (Creates e Updates)
- [x] Validação de dados de entrada com FluentValidation (Creates e Updates)
- [x] Estudar e aplicar o objeto de resultados para camada de domínio (_result-pattern_) 
- [x] Middleware para tratamento de exceções globais
- [ ] Realizar consulta à serviços de API externos
- [ ] Aplicar eventos de domínio