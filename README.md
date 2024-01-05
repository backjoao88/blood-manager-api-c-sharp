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
- [x] A quantidade de ML de sangue doados deve ser entre 420 e 470 ML;
- [x] Não deve permitir cadastro de mais de um tipo de sangue (tipo sanguineo + fator rh);
- [x] Deve atualizar o estoque de sangue ao realizar doação;
- [x] No cadastro de endereço deve ser possível consultar diretamente pelo CEP via API externa;  Dessa forma, caso seja informado o CEP, as informações de cidade, estado e endereço não precisam ser preenchidas.
- [x] Avisar quando o estoque atingir a quantidade mínima definida;
- [x] Deve ser possível consultar o histórico de doações de um doador;
- [x] Deve gerar um relatório sobre a quantidade total de sangue por tipo disponível;
- [x] Deve gerar um relatório de doações nos últimos 30 dias com informações de doadores

### Tecnologias e conceitos aplicados

- [x] Aplicar documentação com o Swagger
- [x] Aplicar um banco de dados de verdade (não em memória)
- [x] Aplicar a separação de serviços de leitura e escrita (CQRS) com padrão Mediator (Creates e Updates)
- [x] Aplicar validação com FluentValidation (Creates e Updates)
- [x] Estudar e aplicar o objeto de resultados para camada de domínio (_result-pattern_) 
- [x] Aplicar um middleware para tratamento de exceções globais
- [ ] Estudar e aplicar eventos de domínio
- [ ] Aplicar testes unitários

### Linkedin

- [x] Realizar publicação
