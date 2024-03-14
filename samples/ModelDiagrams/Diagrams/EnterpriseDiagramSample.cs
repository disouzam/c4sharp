using C4Sharp.Diagrams.Builders;
using C4Sharp.Elements;
using C4Sharp.Elements.Relationships;
using ModelDiagrams.Structures;

namespace ModelDiagrams.Diagrams;

using static People;
using static Systems;
using static C4Sharp.Elements.Relationships.Position;

public class EnterpriseDiagramSample: ContextDiagram
{
    protected override string Title => "System Enterprise diagram for Internet Banking System";

    protected override IEnumerable<Structure> Structures => new Structure[]
    {
        Customer,
        Boundary("enterprise.boundary", "Domain A",
            BankingSystem,
            Boundary("enterprise.boundary.1", "Domain Internal Users", InternalCustomer),
            Boundary("enterprise.boundary.2", "Domain Managers", Manager)
        ),
        Mainframe,
        MailSystem
    };

    protected override IEnumerable<Relationship> Relationships => new[]
    {
        Customer > BankingSystem,
        InternalCustomer > BankingSystem,
        Manager > BankingSystem,
        Customer < MailSystem | "Sends e-mails to",
        BankingSystem > MailSystem | ("Sends e-mails", "SMTP") | Neighbor,
        BankingSystem > Mainframe,
    };
}