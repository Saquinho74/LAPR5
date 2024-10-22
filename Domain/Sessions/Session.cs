using System;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.Shared;

namespace DDDNetCore.Domain.Sessions;

public class Session : Entity<OperationId>, IAggregateRoot
{
    
    public Token Token { get; private set; }
    
    public bool Active { get; private set; }
        
    private Session()
    {
        this.Active = true; // Default to active when created
    }
    
    // Constructor to initialize the Operation entity with required parameters
    public Session(Token token)
    {
        this.Id = new OperationId(Guid.NewGuid()); // Generate a new unique ID
        this.Token = token;
        this.Active = true; // Set operation as active
    }

    public void ChangeToken(Token token)
    {
        if (!this.Active)
            throw new BusinessRuleValidationException("It is not possible to change the token of an inactive session.");
        this.Token = token;
    }
    
    public void Deactivate()
    {
        this.Active = false;
    }
    
}