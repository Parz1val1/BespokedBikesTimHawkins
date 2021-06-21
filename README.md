# BespokedBikesTimHawkins
 A Test Exercise Windows Forms app for Profisee.
 I tried a lot of new things for this test and I think I'm all the better for it.
 - Never used Entity Famework before but thought I'd give it a shot since Patrick said Profisee uses it, tried a code first approach but I didn't know enough to pull it off, but still used EF as my ORM in the end, just a database first approach
 - Never built a UI in winforms either,so that was a new experience too, but thought I'd give it a try since Patrick said the Profisee main monolith was a winforms app.. I don't claim to be a UI/UX master, but it works at the very least! 
 - I tried to make the code as reusable and well separated as possible, and think I did a pretty good job. I'm not experienced enough in winforms to know if there's a better way to do the UI side of things, but again, it all works! 
 - Probably worked too hard on this for just an interview coding test, but I actually enjoyed getting to work at a small scale like this and really try to architect it out and learn the new systems as I went.
# Prompt
BeSpoked Bikes is looking to create a sales tracking application.  BeSpoked is a high-end bicycle shop and each salesperson gets a commission for each bike they sell.  They are introducing a new quarterly bonus based on sales as an incentive.

They are asking you to design a simple sales tracking application to help track the commission and determine each salesperson’s quarterly bonus.  

They will need at a minimum the following components:
# Data layer
- Entities
- Products – Name, Manufacturer, Style, Purchase Price, Sale Price, Qty On Hand, Commission Percentage
- Salesperson – First Name, Last Name, Address, Phone, Start Date, Termination Date, Manager
- Customer – First Name, Last Name, Address, Phone, Start Date
- Sales – Product, Salesperson, Customer, Sales Date
- Discount – Product, Begin Date, End Date, Discount Percentage
- Seed with sample data for testing
#	Middle tier
- Allows for client access to the data layer
# Client
- Display a list of salespersons
- Update a salesperson
- Display a list of products
- Update a product
- Display a list of customers
- Display a list of sales.  Optionally filter by date range.  This should include the Product, Customer, Date, Price, Salesperson, and Salesperson Commission.
- Create a sale
- Display a quarterly salesperson commission report
# Additional Requirements
- Products – No duplicate product can be entered. 
- Salespersons – No duplicate salesperson can be entered. 
