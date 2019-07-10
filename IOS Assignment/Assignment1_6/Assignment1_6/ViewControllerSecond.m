//
//  ViewControllerSecond.m
//  Assignment1_6
//
//  Created by Subhradeep  on 3/21/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import "ViewControllerSecond.h"
#import "CustomCell.h"
#import "ViewControllerThird.h"

@interface ViewControllerSecond () <UITableViewDataSource, UITableViewDelegate> {
    NSUserDefaults *defaults;
    NSString *filePath;
}

@end

@implementation ViewControllerSecond 
@synthesize idData,nameData,positionData,addressData,genderData;

- (void)viewDidLoad {
    [super viewDidLoad];
    idData = [[NSMutableArray alloc]init];
    nameData = [[NSMutableArray alloc]init];
    positionData = [[NSMutableArray alloc]init];
    addressData = [[NSMutableArray alloc]init];
    genderData = [[NSMutableArray alloc]init];
    defaults = [NSUserDefaults standardUserDefaults];
    
    idData = [[defaults objectForKey:@"UserId"]mutableCopy];
    nameData = [[defaults objectForKey:@"UserName"]mutableCopy];
    positionData = [[defaults objectForKey:@"UserPosition"]mutableCopy];
    addressData = [[defaults objectForKey:@"UserAddress"]mutableCopy];
    genderData = [[defaults objectForKey:@"UserGender"]mutableCopy];
}

//- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
//    return 1;
//}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return idData.count;
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    
    static NSString *cellIndex = @"Cell";
    CustomCell *cell = [tableView dequeueReusableCellWithIdentifier:cellIndex];
    
    cell.idDisplay.text = [NSString stringWithFormat:@"Id:%@", [idData objectAtIndex:indexPath.row]];
    cell.nameDisplay.text = [NSString stringWithFormat:@"Name:%@", [nameData objectAtIndex:indexPath.row]];
    cell.positionDisplay.text = [NSString stringWithFormat:@"Position:%@", [positionData objectAtIndex:indexPath.row]];
    cell.genderDisplay.text = [NSString stringWithFormat:@"Gender:%@", [genderData objectAtIndex:indexPath.row]];
    
    NSArray *path = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *documentsPath = [path objectAtIndex:0];
    
    filePath = [documentsPath stringByAppendingPathComponent: [NSString stringWithFormat:@"%@_%@.jpeg", [idData objectAtIndex:indexPath.row], [nameData objectAtIndex:indexPath.row]]];
    
    cell.imageDisplay.image = [UIImage imageWithContentsOfFile:filePath];
    
    return cell;
}

- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
    
    if(editingStyle == UITableViewCellEditingStyleDelete) {
        
        [idData removeObjectAtIndex:indexPath.row];
        [nameData removeObjectAtIndex:indexPath.row];
        [positionData removeObjectAtIndex:indexPath.row];
        [genderData removeObjectAtIndex:indexPath.row];
        [addressData removeObjectAtIndex:indexPath.row];
        
        
        // Removing Data From NSUserDefault
        [defaults removeObjectForKey:@"UserId"];
        [defaults removeObjectForKey:@"UserName"];
        [defaults removeObjectForKey:@"UserPosition"];
        [defaults removeObjectForKey:@"UserGender"];
        [defaults removeObjectForKey:@"UserAddress"];
        
        if((idData.count) != 0) {
            [defaults setObject:idData forKey:@"UserId"];
            [defaults setObject:nameData forKey:@"UserName"];
            [defaults setObject:positionData forKey:@"UserPosition"];
            [defaults setObject:genderData forKey:@"UserGender"];
            [defaults setObject:addressData forKey:@"UserAddress"];
        
            [defaults synchronize];
        } else {
            [defaults synchronize];
        }
        
        [tableView deleteRowsAtIndexPaths:[NSArray arrayWithObject:indexPath] withRowAnimation:UITableViewRowAnimationFade];
    }
}

-(void) prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    if([segue.identifier isEqualToString:@"pushToDetails"]) {
        
        NSIndexPath *indexPath = [self.customView indexPathForSelectedRow];
        ViewControllerThird *third = segue.destinationViewController;
        
        third.demoId = [idData objectAtIndex:indexPath.row];
        third.demoName = [nameData objectAtIndex:indexPath.row];
        third.demoPosition = [positionData objectAtIndex:indexPath.row];
        third.demoAddress = [addressData objectAtIndex:indexPath.row];
        third.demoGender = [genderData objectAtIndex:indexPath.row];
        third.index = indexPath.row;
        
        third.title = [nameData objectAtIndex:indexPath.row];
    }
}

@end
