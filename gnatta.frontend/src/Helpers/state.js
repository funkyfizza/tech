export const changeHandler = (self, field) => ev => self.setState({ [field]: ev.target.value });
