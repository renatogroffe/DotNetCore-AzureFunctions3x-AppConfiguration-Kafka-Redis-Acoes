using FluentValidation;
using FunctionAppProcessarAcoes.Models;

namespace FunctionAppProcessarAcoes.Validators
{
    public class AcaoValidator : AbstractValidator<Acao>
    {
        public AcaoValidator()
        {
            RuleFor(c => c.Codigo).NotEmpty().WithMessage("Preencha o campo 'Codigo'");

            RuleFor(c => c.Valor).NotEmpty().WithMessage("Preencha o campo 'Valor'")
                .GreaterThan(0).WithMessage("O campo 'Valor' deve ser maior do 0");

            RuleFor(c => c.CodCorretora).NotEmpty().WithMessage("Preencha o campo 'CodCorretora'");

            RuleFor(c => c.NomeCorretora).NotEmpty().WithMessage("Preencha o campo 'NomeCorretora'");
        }                
    }
}